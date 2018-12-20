﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dita.Net {
    internal class DitaSearchJson {
        private const string SearchFileName = "search.json";

        public List<DitaPageJson> Pages { get; set; }

        public DitaSearchJson(List<DitaPageJson> pages) {
            Pages = pages;
        }

        // Write this search data to a given folder
        public void SerializeToFile(string output)
        {
            using (StreamWriter file = File.CreateText(Path.Combine(output, SearchFileName)))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings {
                    Formatting = Formatting.Indented
                };
                JsonSerializer serializer = JsonSerializer.Create(settings);
                serializer.Serialize(file, this);
            }

            Console.WriteLine($"Wrote {SearchFileName}");
        }
    }
}