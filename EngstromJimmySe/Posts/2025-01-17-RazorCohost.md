---
title: "Why Hot Reload got better: Razor co-hosting explained"
date: 2025-01-17T00:00:00.000+01:00
categories:
- Blazor
author: Jimmy Engström
tags:
- Blazor
# image: /PostImages/2020-03-21-UsingHighchartsWithBlazor/highcharts.PNG

---


I had a chat with David Wengier about Razor co-hosting. I’d heard the term before, but I didn’t really get what it meant in practice. After David explained it, it finally clicked, and once it clicks, you start seeing why Razor tooling has been such a tricky problem for so long. What really made it click for me was understanding why this change directly affects Hot Reload, making it faster and far more reliable than before.  
This post is a write-up of that conversation, plus the diagram we talked through, and why this matters both for day-to-day dev work and for the long run, including Hot Reload.  

## Razor tooling is not “just Razor”  

A .razor file looks simple until you remember what it actually contains.  
It can mix:  
*	HTML
*	CSS
*	JavaScript
*	C#
*	Razor syntax that glues it together  

All of that is already hard for a single language. Razor is not a single language.  
And editors want to do a lot more than color some keywords.   
We expect:
*	IntelliSense
*	Go to definition
*	Find references
*	Rename
*	Diagnostics, squiggles
*	Formatting

To do that, Visual Studio uses the Language Server Protocol, LSP.  
The important bit is this: an LSP server is meant to answer questions like an API. The editor asks, “If I run go to definition here, where should I go?” and the server answers with a location. The server does not open files, it does not control the UI, it just answers questions.  
That separation is nice, but it matters a lot for how Razor tooling used to work.  

## Before co-hosting, Razor was the middleman between multiple language servers
In the “before” world, multiple language servers were involved.
At minimum: A Razor language server, a C# language server (Roslyn), and an HTML language server. And the HTML side can fan out even further. In Visual Studio, HTML can call into other servers for things like CSS and JavaScript, depending on the scenario. So Razor is sitting in the middle. Translation is basically the job. When the editor asks Razor a question, Razor first has to figure out what language the cursor is actually inside: HTML, including CSS and JavaScript areas, Razor syntax, or C#.   
If it’s HTML, Razor forwards the question to the HTML language server, then filters and maps the response back into the Razor file. The HTML language server knows nothing about Razor and, in most cases, will return many errors. Then, when this is returned to the Razor LSP, it needs to filter out the things that aren't relevant to this file, such as things that aren't valid HTML but are valid Razor syntax.  
If it’s C#, it gets harder.  

## The C# part, mapping into generated code and back again  
Razor is not a normal language in the sense that it is not what runs. Razor gets turned into generated C# behind the scenes.  
So for C# tooling to work, Razor has to do this dance:
1.	Take the position in the .razor file
2.	Map it to the right position in the generated C# file
3.	Ask Roslyn, using LSP, about that generated file position
4.	Get a response
5.	Map the response back into the .razor file coordinates
6.	Filter out stuff that is not useful to show

Every one of these steps adds latency and increases the chances of things going wrong.  
A Razor file might be 20 lines, while the generated C# file might be hundreds of lines. Most of those lines are not “your code”. They are infrastructure code that enables rendering. So even diagnostics are tricky. Roslyn might report an error in line 300 of generated C#, and Razor has to decide: is this actually the user’s code, can we map it to a real location in the Razor file, or is it in an invisible generated area? Sometimes that is why you see the whole document squiggled. The error is real, the project will not build, but the source location is not something you can see directly.  

<image src="\PostImages\2026\Razor Cohosted Before.png" class="center"/>

In reality, this is even more complex. LSP messages cannot go from one Language Server to another, but instead most go through the editor to make those calls. So instead of Razor Language Server directly reaching out to the HTML Language Server or the C# Language Server, it sends the request back to Visual Studio, which then routes it to the appropriate server. This adds even more latency and complexity to the process.

## The part that really hurt, syncing two separate worlds  
The hardest problem was not one specific feature. It was synchronization.  
Razor and Roslyn were separate systems. Razor produced generated C# and had to keep Roslyn up to date with it, so Roslyn could answer questions correctly. But LSP document change messages are basically fire-and-forget. You send updates, and you do not get a meaningful “yep, we are in sync” back. So if anything drifted, even by a little, Razor thought the generated C# looked one way, and Roslyn thought it looked another way. Now the mapping breaks down, and the editor experience gets weird. This is also why restarting Visual Studio could “fix” things. Most of us have seen this. Restarting forces both sides back into a clean, consistent state.  
That is not a satisfying answer, but it matches real life.  

## And then build, and Hot Reload came along and did it all again  
Another major pain point was that the IDE and runtime worlds did not align. When you build and run, Roslyn uses the Razor source generator to generate the same kind of C# output, but that is part of the build pipeline. In the old setup, the IDE side had its own flow, and then when you hit F5, it basically had to toss parts of that and rebuild again through the normal build path. So you had duplicated work, duplicated output, and a lot of effort spent keeping it consistent. Two worlds meant two sources of truth.  
Hot Reload sits on top of that. It needs the build pipeline world, because it is patching changes into the running app. This mismatch is a major reason Hot Reload can feel slow, fragile, or unpredictable, even when nothing is “wrong” with your code.  
Hot Reload was not bad. It was forced to operate in a messy house. You might have seen comments like: "dotnet watch" works better. Heck. I even built a feature in Blazm to simplify running dotnet watch, because I saw the same thing. It wasn't really what was going on. It didn't work better; it just silently restarted.  
In VS 2026, we got the option to add this in our csproj file:
```` xml
<PropertyGroup>
  <HotReloadAutoRestart>true</HotReloadAutoRestart>
</PropertyGroup>
````
This will allow Visual Studio to restart HotReload silently for a better user experience.

## Co-hosting, Razor moves in with Roslyn
This is the shift. Instead of Razor being a separate language server that talks to Roslyn via the LSP, Razor is now co-hosted alongside Roslyn in the same C# language server process. A really important detail is that Razor is not “a separate server inside the server”. It’s more like: Roslyn is the language server; it advertises a bunch of LSP endpoints. Some endpoints are handled by Roslyn for normal C# files, and some are handled by Razor for .razor and .cshtml files.  Razor still exists as Razor. This is about where it lives, not what it is.  Instead of Razor pushing generated code across a boundary, Razor can pull what it needs from Roslyn’s snapshot. From a Hot Reload perspective, this means the IDE and the build pipeline are no longer two separate interpretations of the project.
What gets better right away

### Performance

A lot of overhead goes away:
•	less duplication
•	less translation between systems
•	no LSP round-trip between Razor and Roslyn for C# questions
•	better reuse of caches and incremental work
•	less memory churn
A lot of the speedup isn't the result of a big performance project. It’s simply the result of removing redundant work.

### Reliability

This is the big one. If Razor and Roslyn share the same immutable snapshot model, the “we drifted out of sync” class of issues becomes much harder to hit. That should mean fewer cases where tooling feels random, and fewer times where “restart Visual Studio” is the fix. I’m not going to pretend it removes every bug, but it removes a whole category of problems that existed because of architecture, not because someone wrote a bad if statement.

<image src="\PostImages\2026\Razor Cohosted After.png" class="center"/>

## What this unlocks long-term
Once Razor lives inside Roslyn’s world, it can use Roslyn in a richer way. Before, the bridge between them was LSP: strings, messages, serialization.
Now, Razor code can ask Roslyn for: syntax trees, semantic models, and symbol information. A great example is MVC Tag Helpers. Historically, Razor tooling struggled to go to definition for them in a way that worked well. Once Razor has access to Roslyn’s compilation and symbol model, this becomes much more straightforward.
The same applies to renaming across Razor files, component tags, code-behind, and regular C# code. When everything shares the same project view, these features stop being special cases.

## The Hot Reload angle
Co-hosting is not a Hot Reload feature. Hot Reload is owned by other parts of the stack: Roslyn, the project system, dotnet watch, the debugger side, and so on.
But co-hosting still helps Hot Reload in a very real way.
Because now, when you are editing:
•	The generator is the same generator that build uses
•	It is already running incrementally
•	The output already matches what the build pipeline expects
So when you hit F5 or trigger Hot Reload, you are not switching to a totally different world. Hot Reload gets better not because it was rewritten, but because the system underneath it is no longer fighting itself.

### Closing thoughts

This is one of those changes that does not give us a new API to call or a new syntax feature to blog about.
But it’s foundational.
Razor tooling has always been hard because Razor sits between multiple languages and systems, and the old approach required a lot of translation and syncing across separate processes and project systems. Co-hosting is the moment where someone finally said, “Why are we doing this twice?” Now Razor and Roslyn share the same world. Same snapshots. Same generator. Same understanding of the project. If Hot Reload feels faster and more predictable going forward, it’s not magic. It’s the result of Razor and Roslyn finally living in the same place.
That means better performance, better reliability, and a much better foundation for improving the Razor and Blazor experience over time.

