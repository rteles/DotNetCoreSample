using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DotNetSample.Application.DataTypes.Result
{
    [DataContract]
    public class OperationResult
    {
        public OperationResult()
        {
            this.Success = false;
            this.Code = 0;
            this.Message = string.Empty;
        }

        public OperationResult(bool success)
        {
            this.Success = success;
        }

        public OperationResult(bool success, string message)
        {
            this.Success = success;
            this.Code = !success ? 500 : 200;
            this.Message = message;
        }

        public OperationResult(bool success, int code, string message)
        {
            this.Success = success;
            this.Code = code;
            this.Message = message;
        }

        public OperationResult(bool success, string message, params object[] parameters)
        {
            this.Success = success;
            this.Code = !success ? 500 : 200;
            this.Message = string.Format(message, parameters);
        }

        /// <summary>
        /// Quando aplicável determina o Id do objeto criado ou atualizado pelo processamento especificado.
        /// </summary>
        [DataMember]
        public int? Id { get; set; }

        /// <summary>
        /// Determina se requisição foi realizada e processada com sucesso
        /// </summary>
        [DataMember]
        public bool Success { get; set; }

        /// <summary>
        /// Código do status transação
        /// </summary>
        [DataMember]
        public int Code { get; set; }

        /// <summary>
        /// Mensagem de erro quando aplicável
        /// </summary>
        [DataMember]
        public string Message { get; set; }

    }

    [DataContract]
    public class OperationResult<T> : OperationResult
    {
        public OperationResult() : base() { } // Para deserializar para JSON
        public OperationResult(bool sucess)
            : base(sucess)
        {
            Data = default(T);
        }

        public OperationResult(bool sucess, string message)
            : base(sucess, message)
        {
            Data = default(T);
        }

        public OperationResult(bool sucess, T data)
            : base(sucess)
        {
            this.Data = data;
        }

        public OperationResult(T data, bool success, int code, string message)
            : base(success, code, message)
        {
            this.Data = data;
        }

        public OperationResult(T data, bool success, string message, params object[] parameters)
            : base(success, message, parameters)
        {
            this.Data = data;
        }

        [DataMember]
        [JsonProperty("Data")]
        public T Data { get; set; }
    }

    [DataContract]
    public class OperationResultList<T> : OperationResult
    {
        // Para deserializar para JSON
        public OperationResultList()
            : base()
        {
            Data = null;
        }

        public OperationResultList(bool sucess)
            : base(sucess)
        {
            Data = null;
        }

        public OperationResultList(bool sucess, string message)
            : base(sucess, message)
        {
            Data = null;
        }

        public OperationResultList(bool sucess, IEnumerable<T> data)
            : base(sucess)
        {
            this.Data = data;
        }

        public OperationResultList(IEnumerable<T> data, bool success, int code, string message)
            : base(success, code, message)
        {
            this.Data = data;
        }

        public OperationResultList(IEnumerable<T> data, bool success, string message, params object[] parameters)
            : base(success, message, parameters)
        {
            this.Data = data;
        }

        [DataMember]
        [JsonProperty("Data")]
        public IEnumerable<T> Data { get; set; }
    }
}
