using System;
using System.IO;
using System.Collections.Generic;
using appLotes.models;
using System.Text;

namespace appLotes
{
  public class Program
  {
          static void Main(string[] args)
          {
         Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Seja Bem-vindo ao AppLotes");
        Console.ResetColor();

        Console.WriteLine("usa as setas do teclado ⬆ ⬇ para Navegar no Menu");

        ConsoleKeyInfo key;
        int option = 1;
        bool select = false;
        (int left, int top) = Console.GetCursorPosition();
         string color = "✅ \u001b[32m";
       
       while(!select)
       {
        Console.SetCursorPosition(left, top);
        
        Console.WriteLine($"{(option == 1 ? color : " ")}Option  ler\u001b[0m");
        Console.WriteLine($"{(option == 2 ? color : " ")}Option  esc\u001b[0m");
        Console.WriteLine($"{(option == 3 ? color : " ")}Option  as\u001b[0m");

        key = Console.ReadKey(true);

        switch(key.Key)
        {
          case ConsoleKey.DownArrow:
          option = (option == 3 ? 1 : option + 1);
          break;

          case ConsoleKey.UpArrow:
          option = (option == 1 ? 3 : option - 1);
          break;

          case ConsoleKey.Enter:
          select = true;
          break;
        }
       }
      switch(option){
        case 1: 
        Console.Clear();
      var path = @"C:\Users\Rui\Desktop\appLotes\vite.csv";
      var reader = new StreamReader(File.OpenRead(path));
      var line = reader.ReadLine(); 
      var columns = line.Split(";");

      //Trazendo as posições de cada coluna..
      (int indexdata_venda, int indexquantidade, int indexproduto, int indexpreco_unitario) = setColumnsIndex(columns);
      var lotes = BuildlotesList(reader, indexdata_venda, indexquantidade, indexproduto, indexpreco_unitario);

        foreach (var value in lotes)
        {
             Console.WriteLine($"Data_Venda: {value.data_venda} / Produto: {value.produto} / Quantidade: {value.quantidade} / Preco_Unitario: {value.preco_unitario} ");
        }
        break;
        case 2: 
         Console.Clear();
        Console.WriteLine("Apresentando Esquema...");
        break;
        case 3: 
         Console.Clear();
         int dados1 = 200;
         int dados2 = 400;
         int calculo = dados1 + dados2; 
         int mediaCalculo = dados1 + dados2 / 2;
         Console.WriteLine("Buscar dados ...");
         StringBuilder sb = new StringBuilder();
         Console.WriteLine("Montar Arquivo");
         sb.AppendLine("calculo,mediaCalculo");
         sb.AppendLine($"Calculo {calculo}" + $" mediaCalculo {mediaCalculo}");
         var filePath = @"C:\Users\Rui\Desktop\appLotes\nweArquivo.csv";
         Console.WriteLine("Salvar Arquivo");
         File.WriteAllText(filePath,sb.ToString());
         Console.ReadKey();

        break;
      }
      }
       
      
      //Criando metodo para setar os index, isso de cada valor...
      private static (int,int,int,int) setColumnsIndex(string[] columns){
        Console.WriteLine("Pegando as todas colunas");
        int indexdata_venda = -1;
        int indexproduto = -1;
        int indexquantidade = -1;
        int indexpreco_unitario = -1;

        for (int i = 0; i < columns.Length; i++)
        {
          //verificando se a posição(columns)
          if (string.IsNullOrEmpty(columns[i]))
             continue;
          
          if (columns[i].ToLower() == "data_venda")
          {
            indexdata_venda = i;
            Console.WriteLine($"Posiçao da coluna: {indexdata_venda}");
          }

           if (columns[i].ToLower() == "produto")
          {
            indexproduto = i;
            Console.WriteLine($"Posiçao da coluna: {indexproduto}");
          }

           if (columns[i].ToLower() == "quantidade")
          {
            indexquantidade = i;
            Console.WriteLine($"Posiçao da coluna: {indexquantidade}");
          }
           
           if (columns[i].ToLower() == "preco_unitario")
          {
            indexpreco_unitario = i;
            Console.WriteLine($"Posiçao da coluna: {indexpreco_unitario}");
          }
        }
        return(indexdata_venda, indexproduto, indexquantidade, indexpreco_unitario);

       }
  //Criando a lista de dados
  private static List<PersonModels> BuildlotesList(StreamReader reader, int indexdata_venda, int indexquantidade, int indexproduto, int indexpreco_unitario)
   {
      Console.WriteLine("List");
      string? line;
      var lotes = new List<PersonModels>();
      PersonModels personModels;
      while ((line = reader.ReadLine()) != null)
      {
        
        var values = line.Split(';');
        personModels = new PersonModels();

        if(indexdata_venda != -1)
        
           personModels.data_venda = values[indexdata_venda];

           if(indexproduto != -1)
           personModels.produto = values[indexproduto];
           
             if(indexquantidade != -1)
           personModels.quantidade = values[indexquantidade]; 

              if(indexpreco_unitario != -1)
           personModels.preco_unitario = values[indexpreco_unitario];

           lotes.Add(personModels);
      }
      return lotes;
   }
}

}
