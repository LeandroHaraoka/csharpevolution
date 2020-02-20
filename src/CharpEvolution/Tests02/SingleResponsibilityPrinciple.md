# Single Responsibility Principle

Uma classe deve conter um, e apenas um, motivo para ser modificada. Dois comportamentos pertencem à mesma responsabilidade se ambos mudam juntos. Isso significa que todos os métodos atuam juntos para atingir o objetivo pelo qual a classe foi criada.

O objetivo do SRP é definir classes objetivas, reduzir acomplamento entre elas e facilitar a evolução do desenvolvimento.

No exemplo abaixo, a classe Article possui a responsabilidade de armazenar uma coleção de artigos e controlar o estado interno da coleção adicionando e removendo um artigo.

    public class Article
    {
	    private readonly List<string> entries = new List<string>();
	    private static int count = 0;
    
	    public int AddEntry(string text)
	    {
		    entries.Add($"{++count}:{text}");
		    return count;
	    }
    
	    public void RemoveEntry(int index)
	    {
		    entries.RemoveAt(index);
	    }
	    
	    public override string ToString()
	    {
		    return string.Join(Environment.NewLine, entries);
	    }
	    
	    // breaks single responsibility principle
	    public void Save(string filename)
	    {
		    File.WriteAllText(filename, ToString());
	    }
    }
Perceba que existe um método Save, relacionado à persistencia da coleção em um arquivo. Esse método, apesar de utilizar a coleção para salvar o arquivo, não tem relevância para o estado interno dela. Logo, ele possui uma responsabilidade que não está vinculada à classe Article, o que fere SRP.

Uma abordagem adequada seria segregar a responsabilidade de persistência em uma classe específica. Como abaixo.

      // handles the responsibility of persisting articles
      public class ArticlePersistence
      {
        public void SaveToFile(Article article, string filename)
        {
          if (!File.Exists(filename))
            File.WriteAllText(filename, article.ToString());
        }
      }

