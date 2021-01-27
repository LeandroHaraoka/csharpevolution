# System.Security

O namespace System.Security conta com classes que possuem como objetivo definir a estrutura do sistema de segurança do Common Language Runtime. Através de conjuntos de permissões, configura-se o controle de acesso ao código.

Alguns dos principais elementos do sistema de segurança de acesso ao código serão brevemente apresentados abaixo.

## Permissions
Permissions é uma configuração do acesso a um recurso ou operação protegida. O .NET Core conta com diversas classes de permissão, como FileIOPermission e UIPermission .

## Permission sets
Um permission set é uma coleção de permissões. Pode ser utilizado para validar se um recurso possui um conjunto de permissões.

## Code Groups
Um code group é um agrupamento lógico de recursos que estão sujeito às mesmas políticas de segurança.
