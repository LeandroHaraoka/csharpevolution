# Data Structures

## IEnumerable
As coleções do C# implementam a interface IEnumerable. Esta interface contém um único método GetEnumerator() que retorna um enumerator responsável pela iteração da coleção.

## IEnumerator
A interface IEnumerator é responsável pela iteração em coleções.

### Current

A propriedade current representa o elemento da coleção que está na atual posição do enumerador.

### MoveNext()
O método MoveNext() avança o enumerador para o próximo elemento da coleção e retorna True caso não tenha ultrapassado o final da coleção.

### Reset()
Reseta o enumerador para a posição inicial da coleção.

## Foreach

Função que implementa a interface IEnumerable permitem ser iteradas através da estrutura Foreach. O comportamento do foreach nada mais é do que chamadas iterativas do método MoveNext() do enumerador até que se atinja o final da coleção. Os code blocks abaixo ilustram tal comportamento.
Os comandos abaixo

foreach (string element in stringList)
{
    // action
}

equivalem a

    IEnumerator enumerator = stringList.GetEnumerator();
    while (enumerator.MoveNext())
    {
	    element = (string)enumerator.Current;
	    // action
    }

# Non generic structures

Iniciaremos as data structures pelas não genéricas.

TODO: adicionar image non generic structures

## Array
A estrutra Array (matriz) permite armazenamento sequencial de dados de um mesmo tipo. 

A dimensão e o comprimento de cada dimensão não podem ser alterados após a instanciação da array.

Um elemento de uma array é acessado por meio do seu respectivo índice.

Uma array pode ser instanciada das seguintes formas. 

    var  singleDimensionalIntegers = new  int[] {1 ,2 ,3 ,4 ,5};
    var  singleDimensionalIntegers = new  int[10];

Elas ainda podem ter mais de uma dimensão.

    var  snd = TerrainType.Sand;
    var  grs = TerrainType.Grass;
    var  wll = TerrainType.Wall;
    var  wtr = TerrainType.Water;
    
    TerrainType[,] map =
    {
    {snd, snd, snd, snd, grs, grs, grs, grs, grs, grs},
    {snd, snd, snd, snd, grs, grs, grs, grs, grs, grs},
    {snd, snd, snd, snd, grs, grs, grs, grs, grs, grs},
    {snd, snd, snd, snd, grs, grs, grs, grs, grs, grs},
    {snd, snd, snd, snd, snd, snd, snd, wll, wll, wll},
    {snd, snd, snd, snd, snd, snd, snd, wll, snd, snd},
    {snd, snd, snd, snd, snd, snd, snd, wll, snd, snd},
    {wtr, wtr, wtr, wtr, wtr, wtr, wtr, wll, snd, snd},
    {wtr, wtr, wtr, wtr, wtr, wtr, wtr, wll, snd, snd},
    {wtr, wtr, wtr, wtr, wtr, wtr, wtr, wll, wtr, wtr},
    {wtr, wtr, wtr, wtr, wtr, wtr, wtr, wll, wtr, wtr}
    };
Suponha que TerrainType seja um enum e cada um dos seus itens seja printado em uma cor específica. O resultado seria o seguinte.

TODO: adicionar o terrain type.

## LinkedList

A Linkedlist é uma implementação de uma lista duplamente ligada. Isso significa que cada elemento possui um ponteiro para o seu antecessor e outro para seu sucessor. Dessa forma, não existe indexação.

TODO: Adicionar imagem da linked list

Podemos operar em uma LinkedList da seguitne forma:

    var linkedList = new  LinkedList<string>();
    var nodeOne = new  LinkedListNode<string>("One");
    var nodeTwo = new  LinkedListNode<string>("Two");
    var nodeThree = new  LinkedListNode<string>("Three");
    
    linkedList.AddLast(nodeOne);
    linkedList.AddLast(nodeTwo);
    linkedList.AddLast(nodeThree);
    linkedList.AddAfter(linkedList.Find("Two"),"TwoAndAHalf");

 Pelo fato de não haver indexação, as operações de insert e delete acontecem de forma relativamente eficiente, pois não existe o "shift" dos elementos.

## ArrayList

A estrutura ArrayList implementa a interface IList e armazena dados do tipo object. A ArrayList é um array com tamanho dinâmico podendo ser incrementado sob demanda.

Esta estrutura era comumente utilizada antes da chegada dos generics (List<T>).  Uma arraylist pode ser instanciada e manipulada da seguinte forma por exemplo:

    var  arrayList = new  ArrayList();
    arrayList.Add("Numbers");
    arrayList.Add(1);
    arrayList.AddRange(new  int[] {2, 3, 4});

## SortedList

Uma SortedList é uma sequência de key value pair, ordenados com base nos valores das keys. Cada elemento pode ser acessado através da sua key ou do seu índice na sequência. Quando inserimos um elemento na sorted list, ele já é adicionado na ordenaçãao correta. O exemplo mostra como criar e adionar valores na SortedList.

    var  sortedList = new  SortedList<string, string>();
    sortedList.Add("3", "Marcos");
    sortedList.Add("2", "Julia");
    sortedList.Add("1", "Pedro");

