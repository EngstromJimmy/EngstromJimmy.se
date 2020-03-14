cd "c:\build15"

$pattern = "[{0},\:,\']" -f ([Regex]::Escape([String][System.IO.Path]::GetInvalidPathChars()))              
[Environment]::CurrentDirectory=(Get-Location -PSProvider FileSystem).ProviderPath 
$a = ([xml](new-object net.webclient).downloadstring("http://channel9.msdn.com/Events/Build/2015/RSS/wmvhigh")) 
$a.rss.channel.item | foreach{  
    $url = New-Object System.Uri($_.enclosure.url) 
    $file = [Regex]::Replace($_.Title + " " + $url.Segments[-1] , $pattern, ' ') 
    Write-host  ("{0}  -  {1}" -f "Downloadning" ,$file)
    if (!(test-path $file)) 
    { 
            (New-Object System.Net.WebClient).DownloadFile($url, $file) 
    } 
}