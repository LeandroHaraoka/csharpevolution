
# SystemIO

O namespace System.IO é constituído de classes que fornecem ferramentas para gerenciamento de fluxo de dados. Tais fluxos podem ser do tipo leitura e escrita de arquivos, transferência de dados em rede e troca de dados em memória. Para cada categora de fluxo de dados existem classes responsáveis pelo gerenciamento, como FileStream, NetworkStream e MemoryStream. Estas classes herdam comportamentos da classe abstrata Stream, que define propriedades e métodos pertinentes ao fluxo de dados. Além disso, existem algumas classes que herdam de Stream que fornecem extensões às funcionalidades básicas.

## DirectoryInfo

A classe DirectoryInfo fornece métodos de instância para manipulação de diretórios. Cria-se uma instância passando-se o path no construtor do objeto. 

    var  dir  =  new  DirectoryInfo("C:\\Users\\name\\Downloads");

Um DirectoryInfo contém funções de criar, mover e deletar, por exemplo. Também existem métodos que retornam os subdiretórios e arquivos contidos no path fornecida na instanciação do objeto, conforme no exemplo abaixo.

     var  dir  =  new  DirectoryInfo("C:\\Users\\name\\Downloads");

    dir.GetFiles();
    dir.GetDirectories();
	dir.EnumerateFiles();
    dir.EnumerateDirectories();
    
Neste caso, os métodos "get" retornam arrays de FileInfo ou DirectoryInfo. Já  os métodos "Enumerate" retornam Enumerables de FileInfo e DirectoryInfo.

## Directory versus DirectoryInfo
A classe Directory possui funções com o mesmo propósito das funções de DirectoryInfo, porém estáticas. 

Isto quer dizer que, por não ser instanciável, esta classe tem uso mais apropriado para cenários que desejamos realizar poucas e simples manipulações. Por exemplo, podemos usar Directory para realizar uma simples deleção.

Por outro lado, se desejamos realizar diversas operações em um mesmo path, é mais adequado trabalharmos com uma instância de DirectoryInfo. Por exemplo, em um cenário onde queremos realizar operações de criação, mover, listagem de arquivos e subdiretórios, deleções, todas em um mesmo path. 

## File versus FileInfo
As classes File e FileInfo proporcionam métodos com o propósito de prover manipulação de arquivos. Da mesma forma que acontece para diretórios, a manipulação de arquivos pode ser realizada com métodos de instância, via objetos FileInfo, ou com métodos estáticos, via classe File.

## Iterando em uma árvore de diretórios

Para obter todos diretórios e subdiretórios contidos em um path, pode-se utilizar o seguinte comando. 

    root.GetDirectories("*.*", System.IO.SearchOption.AllDirectories);

A desvatagem desse comando é que, caso ocorra um DirectoryNotFoundException ou um UnauthorizedAccessException, a busca de todos os diretórios falhará. Para evitar isso, pode-se iterar manualmente, tratando as exceções pontualmente. O exemplo mostrará uma abordagem por meio de pilha.

```
public class StackBasedIteration
{
    static void Main(string[] args)
    {
        TraverseTree(args[0]);
        Console.WriteLine("Press any key");
        Console.ReadKey();
    }

    public static void TraverseTree(string root)
    {
        Stack<string> dirs = new Stack<string>(20);

        if (!System.IO.Directory.Exists(root))
            throw new ArgumentException();

        dirs.Push(root); // Adiciona o diretorio raiz.

        while (dirs.Count > 0)
        {
            string currentDir = dirs.Pop(); // 
            string[] subDirs;
            try
            {
                subDirs = System.IO.Directory.GetDirectories(currentDir);
            }

            catch (UnauthorizedAccessException e)
            {                    
                Console.WriteLine(e.Message);
                continue;
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }

            string[] files = null;
            try
            {
                files = System.IO.Directory.GetFiles(currentDir);
            }

            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            
            foreach (string file in files)
            {
                try
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(file);
                    Console.WriteLine("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
                }
                catch (System.IO.FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            foreach (string str in subDirs)
                dirs.Push(str);
        }
    }
}
```


## Streams

### StreamReader 

A classe StreamReader implementa a classe abstrata TextReader e sobrescreve os métodos que realizam a leitura de caracteres a partir de um stream de bytes dada uma codificação.

### StreamWriter

A classe StreamWriter implementa  a classe abstrata TextWriter e sobrescreve os métodos que realizam a escrita de caracteres para uma stream dada uma codificação.

### FileStream

A classe FileStream disponibiliza funcionalidades para manipulação de arquivo como escrita, leitura, abertura e fechamento, entre outras. 

A primeira dúvida a ser respondida é a diferença entre as funcionalidades das classes File, FileStream, StreamReader e StreamWriter. 

Alguns pontos a serem considerados:
 - Os métodos da classe File invocam métodos das classes StreamReader e
   StreamWriter. 
   
 - Os métodos da classe FileStream permitir maior controle
   sobre a manipulação de arquivos.

As funcionalidades da classe File nada mais são do que abstrações para StreamReader e StreamWriter. Se quisermos maior poder de configuração da leitura e a escrita de arquivos, podemos usar estes dois últimos. Caso ainda não seja suficiente, podemos utilizar a classe FileStream.

Porém, os métodos de Read e Write da classe FileStream manipulam Bytes, mas não strings, o que torna necessária a conversão do tipo dos dados. É aí então que aparecem a conveniência de combinar a classe FileStream com StreamReaders e StreamWriters.

## Reading files

O primeiro exemplo mostra uma implementação do StreamReader construído a partir de um path.
```
try
{
   // Open the text file using a stream reader.
    using (StreamReader sr = new StreamReader("TestFile.txt"))
    {
	    // Read the stream to a string, and write the string to the console.
        String line = sr.ReadToEnd();
        Console.WriteLine(line);
    }
}

catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}
```

No próximo exemplo, ainda utilizamos StreamReader, porém construído a partir de um FileStream. Neste caso, o uso do FileStream permite maior controle sobre a leitura, disponibilizando argumentos como FileMode, FileAccess, FileShare que são, respectivamente, configurações de modo de abertura de arquivo, de permissão de acesso e de permissão de acesso para outros FileStreams.
```
FileStream fsIn = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read, FileShare.Read);

// Create an instance of StreamReader that can read
// characters from the FileStream.
using (StreamReader sr = new StreamReader(fsIn))
{
    string input;
    // While not at the end of the file, read lines from the file.
    while (sr.Peek() > -1)
    {
        input = sr.ReadLine();
        Console.WriteLine(input);
    }
}
```

## Escrevendo arquivos

Neste exemplo, a escrita é realizada diretament pela implementação do StreamWriter para um **novo arquivo**.
```
// Write the string array "lines" to a new file named "WriteLines.txt".
using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
{
    foreach (string line in lines)
        outputFile.WriteLine(line);
}
```
No próximo exemplo, mostraremos como utilizar o StreamWriter para escrever em um arquivo já existente, apendando o seu conteúdo. O booleano true indica que o conteúdo deve ser appendado. Caso fosse false, o conteúdo seria sobreescrito. Se o arquivo não existir previamente, será criado um novo arquivo.
```
// Append text to an existing file named "WriteLines.txt".
using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt"), true))
{
    outputFile.WriteLine("Fourth Line");
}
```

Fica o desafio para a escrita de arquivos utlizando a composição de FileStream com StreamWriter, a fim de permitir maior controle na manipulação dos arquivos.
