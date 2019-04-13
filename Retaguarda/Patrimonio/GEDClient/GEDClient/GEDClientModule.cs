using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace GEDClient
{
    public class GEDClientModule :IModule
    {
        private RegionManager regionManager;

        public GEDClientModule(RegionManager rManager)
        {
            this.regionManager = rManager;
        }

        public void Initialize()
        {
            IRegion region = regionManager.Regions["moduloGED"];
            View.GED.GedDocumentoPrincipal gedView = new View.GED.GedDocumentoPrincipal();
            region.Add(gedView);
            region.Activate(gedView);
        }
    }
}
