# Liskov Substitution Principle

O princípio da Substituição de Liskov define que uma classe filha (que herda uma base class ou implementa um interface) deve ser utilizada no lugar de sua classe pai sem que haja alteração indesejada no comportamento da aplicação e sem a necessidade de verificação do tipo filho. Ou seja, uma implementação deve substituir uma abstração sem a geração de prejuízos semânticos.

Barbara Liskov, uma estadunidense cientista da computação , apresentou o conceito do LSP como uma abordagem para o uso adequado do polimorfismo de subtipos:

> Sendo uma função f(x) e x um objeto do tipo T, então f(y) deve ser verdadeiro e não deve ter comportamento alterado para um objeto y do tipo S, dado S um subtipo de T.

Quando o pricípio da substituição de Liskov é desrespeitado, implica-se em um objeto que não atende adequadamente o contrato imposto pela abstração. 

## Following OCP but not LSP

No código abaixo, temos um exemplo de design que atende o princípio do aberto-fechado, porém desrespeita substituição de Liskov. 

```
public interface IPerson {}

public class Boss : IPerson
{
    public void DoBossStuff() {...}
}

public class Peon : IPerson 
{
    public void DoPeonStuff() {...}
}

public class Context 
{
    public IEnumerable<IPerson> GetPersons() {...}
}
```
Com a implementação acima, temos que a interface IPerson atende diferentes tipos de pessoas, cada um com sua implementação, tornando a interface aberta para extensão (novos tipos) mas fechada pra modificações (um tipo novo não altera a abstração).

Porém, na utilização do método GetPersons(), teremos uma coleção de IPersons e, para acessar o método de cada item, teríamos que validar o seu tipo e fazer o cast. Sendo asssim, desrespeita-se o princípio de Liskov, pois o tipo da implementação influencia no comportamento da aplicação.

Para seguir o LSP, refatora-se o código da seguinte forma.

```
public interface IPerson 
{
    public void DoStuff();
}

public class Boss : IPerson {

    public void DoStuff() 
    {
        this.DoBossStuff();
    }
    
    public void DoBossStuff() { ... }
}

public class Peon : IPerson {

    public void DoStuff() 
    {
        this.DoPeonStuff();
    }
    
    public void DoPeonStuff() { ... }
}
```
Neste novo design, podemos invocar o método de cada tipo de pessoa, simplesmente fazendo person.DoStuff(), pois todos tipos específicos implementam o método DoStuff(). Isso dispensa a necessidade de validação e conversão de tipos.

Os princípios de POO atuam em conjunto para atender paradigmas de projetos orientados à objeto. O LSP e o OCP atuam como princípios que extendem o conceito um do outro e, como apresentado, podem ser aplicados individualmente, mas em conjunto garantem os paradigmas de formas mais efetiva.