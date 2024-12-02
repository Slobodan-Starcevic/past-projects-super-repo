using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Enclosure
    {
        private Guid id;
        private string name;
        private List<Content>? webContent;
        private string url;
        private bool showOnWeb;
        private string? pfpURL;

        //Constructor for new enclosure creation
        public Enclosure(string name)
        {
            Guid newGuid = Guid.NewGuid();
            this.Id = newGuid;
            this.Name = name;
            this.Url = $"/enclosures?id={newGuid}";
            this.ShowOnWeb = false;
        }

        //Constructor for employee retrieval from database
        public Enclosure(Guid id, string name, string url, bool onWeb, string? pfpurl)
        {
            this.Id = id;
            this.Name = name;
            this.Url = url;
            this.ShowOnWeb = onWeb;
            this.PfpURL = pfpurl;
        }

        public Enclosure(Guid id, string name, string url)
            :this(id, name, url, false, null)
        {
        }

        public void AddContent(List<Content> contents)
        {
            WebContent.AddRange(contents);
        }

        public Guid Id { get => id; private set => id = value; }
        public string Name { get => name; private set => name = value; }
        public List<Content>? WebContent { get => webContent; private set => webContent = value; }
        public string Url { get => url; private set => url = value; }
        public bool ShowOnWeb { get => showOnWeb; private set => showOnWeb = value; }
        public string? PfpURL { get => pfpURL; set => pfpURL = value; }
    }
}
