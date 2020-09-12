using IMS.Shared.Models;

namespace IMS.Client.Shared
{
    class QuoteState
    {
        public int QuoteId { get; set; }
        public string Lang { get; set; }
        public Vehicle Vehicle { get; set; }
        public Driver Driver { get; set; } //used when adding driver to Vehicle
        public bool UnsavedData { get; set; }
    }
}
