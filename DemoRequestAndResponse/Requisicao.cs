using RestSharp;

namespace DemoRequestAndResponse
{
    public interface Requisicao
    {
        public IRestResponse RequisicaoPOST();

        public IRestResponse RequisicaoGET();
    }
}
