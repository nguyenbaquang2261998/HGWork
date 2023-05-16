using Newtonsoft.Json;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace HGWork.DTO.Kafka
{
    public class MessageEvent<TData>
    {
        public MessageEvent() { }
        public MessageEvent(TData data)
        {
            Data = JsonConvert.SerializeObject(data);
        }
        public MessageEvent(TData data, string type, string streamKey, bool isKey, int currVersion)
        {
            this.LogDate = DateTime.Now;
            if (data != null)
            {
                this.Data = JsonConvert.SerializeObject(data);
            }
            else
            {
                this.Data = "";
            }

            if (!string.IsNullOrEmpty(streamKey))
            {
                if (isKey)
                {
                    var guid = "";
                    using (MD5 md5 = MD5.Create())
                    {
                        byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(streamKey));
                        Guid result = new Guid(hash);
                        guid = result.ToString();
                    }
                    this.StreamId = guid;
                }
                else
                {
                    this.StreamId = streamKey;
                }
            }
            else
            {
                this.StreamId = "";
            }

            if (!string.IsNullOrEmpty(type))
            {
                this.Type = type;
            }
            else
            {
                this.Type = "";
            }
            this.CurrVersion = currVersion;
        }
        public TData ConvertData()
        {
            return JsonConvert.DeserializeObject<TData>(this.Data);
        }

        public string Type { get; set; }
        public string StreamId { get; set; }
        [DefaultValue(1)]
        public int CurrVersion { get; set; }
        [DefaultValue("")]
        public string Data { get; set; }
        [DefaultValue("")]
        public string Meta { get; set; }
        [DefaultValue(0)]
        public int ErrorCode { get; set; }
        [DefaultValue("")]
        public string Message { get; set; }
        public DateTime LogDate { get; set; }
    }
}
