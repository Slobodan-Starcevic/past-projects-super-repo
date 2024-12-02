using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BLL.Interfaces.Services;
using WebApp.DTO;
using BLL.Models;
using WebApp;
using Microsoft.AspNetCore.Hosting;

namespace ZooBazaar_WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEnclosureService _enclosureService;
        private readonly IContentService _contentService;
        public List<EnclosureDTO> AllEnclosures { get; set; }
        public Dictionary<Guid, string> ContentList { get; set; }

        public IndexModel(IEnclosureService enclosureService, IContentService contentService)
        {
            _enclosureService = enclosureService;
            _contentService = contentService;
            AllEnclosures = new List<EnclosureDTO>();
            ContentList = new Dictionary<Guid, string>();
        }

        public void OnGet()
        {
            var rawList = _enclosureService.GetEnclosures();

            foreach (Enclosure enc in rawList)
            {
                if(enc.ShowOnWeb == true)
                {
                    var content = _contentService.GetEnclosureContents(enc.Id);
                    if (content != null)
                    {
                        ContentList.Add(enc.Id, content[0].ImageUrl);
                    }

                    if (enc.ShowOnWeb == true)
                    {
                        EnclosureDTO dto = new EnclosureDTO
                        {
                            Id = enc.Id,
                            Name = enc.Name,
                            URL = enc.Url,
                            PFPURL = enc.PfpURL
                        };
                        AllEnclosures.Add(dto);
                    }
                }
            }
        }
    }
}