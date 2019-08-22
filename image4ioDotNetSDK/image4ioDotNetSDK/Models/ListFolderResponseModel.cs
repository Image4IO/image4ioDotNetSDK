using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace image4ioDotNetSDK.Models
{
   public class ListFolderResponseModel : BaseResponseModel
    {


        public List<Folder> folders { get; set; }
        public List<File> files { get; set; }
        public class Folder
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("parent")]
            public string Parent { get; set; }
        }



        public class File
        {
            [JsonProperty("folder")]
            public string Folder { get; set; }

            [JsonProperty("orginal_name")]
            public string Orginal_name { get; set; }

            [JsonProperty("name")]
            public string Name{ get; set; }

            [JsonProperty("size")]
            public int Size { get; set; }

            [JsonProperty("format")]
            public string Format { get; set; }

            [JsonProperty("width")]
            public int Width { get; set; }

            [JsonProperty("height")]
            public int Height { get; set; }

            [JsonProperty("createdat")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedat")]
            public DateTime UpdatedAt { get; set; }


        }

  

    }
}
      