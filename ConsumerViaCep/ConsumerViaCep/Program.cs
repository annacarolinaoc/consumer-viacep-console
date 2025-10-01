using System.Text.Json;
using ConsumerViaCep.Models;
using static System.Console;

WriteLine("Digite o seu cep: ");
var cep = ReadLine();

var enderecoUrl = $@"https://viacep.com.br/ws/{cep}/json/";

var client = new HttpClient();

try
{
    HttpResponseMessage? respostaApi = await client.GetAsync(enderecoUrl);

    respostaApi.EnsureSuccessStatusCode();

    string respostaApiJson = await respostaApi.Content.ReadAsStringAsync();

    Endereco? endereco = JsonSerializer.Deserialize<Endereco>(respostaApiJson);

    WriteLine("CEP:" + endereco.cep);
    WriteLine("Logradouro:" + endereco.logradouro);
    WriteLine("Bairro:" + endereco.bairro);
    WriteLine("Cidade:" + endereco.localidade);
}
catch (System.Exception e)
{

    WriteLine("Aconteceu um erro:\n" + e.Message);
}