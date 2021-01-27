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

A estrutra Array (matriz) é uma coleção que implementa a interface IList, permitindo armazenamento sequencial de dados de um mesmo tipo. 

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

Uma SortedList é uma sequência de key value pair ordenados com base nos valores das keys. Ela implementa a interface IDictionary. Cada elemento pode ser acessado através da sua key ou do seu índice na sequência. Quando inserimos um elemento na sorted list, ele já é adicionado na ordenaçãao correta. O exemplo mostra como criar e adionar valores na SortedList.

    var  sortedList = new  SortedList<string, string>();
    sortedList.Add("3", "Marcos");
    sortedList.Add("2", "Julia");
    sortedList.Add("1", "Pedro");

## Dictionary

Dictionary é uma coleção de pares chave-valor que implementa a interface IDictionary.

	var phoneBook =  new Dictionary<string, string>()
    {
		{"Larissa", "(11) 94826-5436"},
        {"Manuel", "(11) 95883-1853"},
        {"Fernando", "(11) 93057-1779"}
    };

O dictionary não permite a inserção de chaves duplicadas. 

    phoneBook.Add("Larissa", "(11) 96666-4533");
    
Caso a operação acima seja executada, lança-se uma exceção do tipo *ArgumentException*. Pode-se utilizar o método ContainsKey antes de realizar uma inserção, para evitar o lançamento da exceção.

Porém, são permitidas alterações no valor de uma chave existente . No comando abaixo, altera-se o valor correspondente à chave "Larrisa".

    phoneBook["Larissa"] = "(11) 99999-5555";

Também lança-se uma exception, do tipo *KeyNotFoundException*, caso tentamos acessar uma chave que não existe no dictionary. Caso se deseja evitar o lançamento de exceções, é mais adequado utilizar o método TryGetValue do dictionary.

## Hashtable
A Hashtable, assim como o Dictionary, é uma coleção de pares chave-valor. As duas estruturas são utilizadas em contextos similares, mas apresentam diferenças relevantes. A Hashtable não é uma estrutura do tipo genética, diferentemente do dictionary, e não garante a segurança de tipos das chaves e dos valores, os pares são do tipo <object, object>. O exemplo abaixo demonstra a instanciação de uma Hashtable e a adição de um elemento com valor com tipo diferente dos outros.

    Hashtable  phoneBook = new  Hashtable()
    {
	    {"Larissa", "(11) 94826-5436"},
	    {"Manuel", "(11) 95883-1853"},
	    {"Fernando", "(11) 93057-1779"}
    };
    phoneBook.Add("Maria", 12345);

As chaves de uma hashtable também não podem ser duplicadas. Porém, a consulta de uma chave difere do dictionary por não lançar uma exception quando a chave não é encontrada, mas sim retornar nulo.

## Hashset

O Hashset é uma estrutura genérica que contém uma coleção de valores únicos. Quando tenta-se adicionar, pelo método Add, um valor já existente na coleção, retorna-se um boleano com valor igual a falso. 
A hashset conta com operações matemáticas, pode-se por exemplo encontrar a união e a intersecção entre duas coleções do tipo hashset.

    HashSet<int> usedCoupons = new  HashSet<int>();
    var firstInsertion = usedCoupons.Add(1);
    var secondInsertion = usedCoupons.Add(1); // Esta execução retorna um boleano falso.

## Stack

A estrutura Stack representa uma coleção de elementos que segue a lógica LIFO (last-in-first-out), o que significa que o único elemento acessível é o último que foi adicionado à coleção.

    Stack<int> stack = new  Stack<int>();
Pode-se realizar uma operação de inserção por meio do método Push, como abaixo.

    stack.Push(number);
    
O acesso é realizado pelo método Peek.

    var valueFromTop = stack.Peek();

A remoção dos elementos de uma stack seguem também a lógica LIFO (remove o último valor adicionado) com o método Pop.

    var removedValue = stack.Pop();
Pode-se ainda limpar a stack utilizando o método Clear.

    stack.Clear();

## Queue

A queue é uma coleção de elementos que segue a lógica FIFO (first-in-first-out), o que significa que o acesso aos elementos é permitido por ordem de chegada.
Pode-se instanciar uma queue e adicionar elementos nela da seguinte maneira:

    var calls = new Queue<IncomingCall>();
    var call = new IncomingCall();
    calls.Enqueue(call);

A consulta e a retirada de um elemento da queue são apresentadas abaixo:

    var peekCall = calls.Peek();
    var dequeuedCall = calls.Dequeue();
