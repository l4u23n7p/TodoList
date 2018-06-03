using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Models
{
    public class TodoItem
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; } = 0;
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; } = "";
        [JsonProperty(PropertyName = "createdDate")]
        public DateTime CreatedDate;
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; } = "";
        [JsonProperty(PropertyName = "isDone")]
        public bool IsDone { get; set; } = false;
        [JsonProperty(PropertyName = "doneDate")]
        public dynamic DoneDate { get; set; } = "";
        [JsonProperty(PropertyName = "priority")]
        public int Priority { get; set; } = 3;
    }
}
