# TI-Dr.LavaTudo
Teste para a vaga de estágio.

Resposta Teste

Tarefa 1: Quais alterações devemos fazer nessa estrutura para que o cliente consigo fazer mais de um serviço por solicitação?
Para permitir que o cliente faça mais de uma solicitação, deveríamos criar uma nova tabela chamada {servicos_ordem} com os atributos <idServico> e <idOrdemServico> (formando ambos a chave primaria desta nova tabela), com isso seria possível cadastrar vários serviços a uma mesma ordem, os conectando com essa nova tabela.
A estrutura ficaria:
OrdemServico(idOrdemServico <Pk>, idClinte <Fk>, DatContratacao, DataExecucao)
Serviços_ordem((idOrdemServico<Fk>, idServico <Fk>)<Pk)
Obs. Nessa forma o mesmo serviço não poderia ser feito duas vezes na mesma ordem.

Tarefa 2: E se a mesma ordem de serviço tivesse serviços para endereços diferentes. Como ficaria a nova estrutura de dados?
Criando uma tabela endereço, poderíamos adicionar o <<idEndereco>> a tabela {serviço_ordem} referenciando onde o serviço devera ser executado.
Serviços_ordem((idOrdemServico<Fk>, idServico <Fk>, idEndereco)<Pk)
Obs. Nessa forma vai ser possível que o mesmo serviço seja realizado na mesma ordem, porem não no mesmo local com a mesma ordem.
Obs. Também poderíamos modificar a Estrutura colando a data de execução em {serviço_ordem} para que serviços diferente s pudessem ser executados em datas diferentes.

Tarefa 3: Utilizando qualquer Linguagem de Consulta Estruturada (SQL) e considerando a nova estrutura de dados criada na questão anterior:
Foi utilizado um banco de dado em MySQL para executar a tarefa:

a) Selecione todos os clientes e a quantidade de ordem de serviços
SELECT Cli.idCliente, NomeCliente, EmailCliente,DataNascimentoCliente, TelCelularCliente, COUNT(*)
FROM cliente Cli JOIN ordemservico Ord ON Cli.idCliente = Ord.IdCliente
GROUP BY idCliente

b) Selecione todas as Ordens de Serviços com mais de um serviço
SELECT Ord.idOrdemServico, Ord.idCliente, count(*)
 FROM ordemservico Ord JOIN servicos_ordem_local ServO ON Ord.idOrdemServico = ServO.IdOrdemServico
 GROUP BY idOrdemServico 
 HAVING Count(Ord.idOrdemServico)>1;

c) Selecione os serviços mais vendidos
Não conseguir realizar esta tarefa

d) Atualize o valor final de todos os serviços em 12%
UPDATE  servico SET ValorFinalServico = (ValorFinalServico + (ValorFinalServico*0.12));
Obs.: O MySQL possui uma opção de segurança que não permite que o update seja alterado sem a clausula WHERE, para caso se não queira desativar essa opção, mas executar a ação poderia ser feita da seguinte maneira:
UPDATE  servico SET ValorFinalServico = (ValorFinalServico + (ValorFinalServico*0.12))
WHERE idServico >0;

e) Remova a ultima ordem de serviço criada
set @maior_id = (select max(idOrdemServico) from ordemservico);
delete from ordemservico where idOrdemServico = @maior_id;

f) Insira um cliente
INSERT INTO cliente (`NomeCliente`, `EmailCliente`, `DataNascimentoCliente`, `TelCelularCliente`, `TelResidencialCliente`) VALUES ('Teste', 'teste@teste', '1990-01-01', '31 999999999', '31 999999999');

Referente à segunda parte, comecei a realizar o procedimento, mas como não possuía conhecimento em criação de Api, não conclui a tarefa.
