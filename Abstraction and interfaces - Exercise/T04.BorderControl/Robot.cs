using System;
namespace T04.BorderControl
{
    public class Robot : IObject
    {
        public string Model { get; set; }

        public string Id { get; set; }

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
    }
}

