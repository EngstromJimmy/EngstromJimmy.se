using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace EngstromJimmySe.Services
{
    public class AppStateService : INotifyPropertyChanged
    {

        public AppStateService()
        {
            ReadSettings();

        }


        public void ReadSettings()
        {
            var yamlDeserializer = new DeserializerBuilder().
                                WithNamingConvention(new PascalCaseNamingConvention())
                                .IgnoreUnmatchedProperties()
                                .Build();
            var settings = File.ReadAllText("config.yaml");
            Configuration = yamlDeserializer.Deserialize<Config>(settings);
        }

    public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string title;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public Config Configuration { get; set; }
    }
}
