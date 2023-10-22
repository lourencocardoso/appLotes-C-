namespace appLotes.models

{
  //Modelagem dos dados vindo da planilha(venda.csv), me faz lembrar modelagem do banco de dados 
  public class PersonModels
  {
    public string? data_venda {get; set;} 
    public string? produto {get; set;} 
    public string? quantidade {get; set;} 
     public string? preco_unitario {get; set;} 
  }
}