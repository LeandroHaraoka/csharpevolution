
# SystemData
O namespace System.Data contém classes, interfaces e métodos que permitem a manipulação de várias fontes de dados de fontes. 

## DataTable
A classe DataTable representa uma tabela de dados. Como o conceito de tabela é trivial, vamos apresentar um exemplo de como construir uma tabela usando uma instância de DataTable.

    System.Data.DataTable table = new DataTable("NomeDaTabela");
 
Agora, adicionarem as colunas Id e Data.

 
    DataColumn column;
	
	// Cria a coluna "Id"
    column = new DataColumn();
    column.DataType = System.Type.GetType("System.Int32");
    column.ColumnName = "id";
    column.ReadOnly = true;
    column.Unique = true;
    table.Columns.Add(column);
    
    // Cria a coluna "Data"
    column = new DataColumn();
    column.DataType = System.Type.GetType("System.String");
    column.ColumnName = "Data";
    column.AutoIncrement = false;
    column.Caption = "ParentItem";
    column.ReadOnly = false;
    column.Unique = false;
    table.Columns.Add(column);

Então, tornamos a coluna Id chave primária da tabela.

    // Make the ID column the primary key column.
    
    DataColumn[] PrimaryKeyColumns = new DataColumn[1];
    PrimaryKeyColumns[0] = table.Columns["id"];
    table.PrimaryKey = PrimaryKeyColumns;

## DataSet

O DataSet é um cache de dados na memória composto por um conjunto de DataTables relacionadas através de DataRelations.
O código abaixo adiciona a tabela criada anteriormente no cache de dados.

    dataSet = new DataSet(); 
    dataSet.Tables.Add(table);

Para adicionar relacionamentos entre duas tabelas, pode-se seguir assim.

    DataColumn parentColumn = dataSet.Tables["ParentTable"].Columns["id"]; 
    DataColumn childColumn = dataSet.Tables["ChildTable"].Columns["ParentId"]; 
    DataRelation relation = new DataRelation("parentChild", parentColumn, childColumn);    
    dataSet.Tables["ChildTable"].ParentRelations.Add(relation);
