# Rent_and_Delivery

Banco de dados

#1. **Admin:**
   - Identificador (chave primária)
   - Nome
   - Data de Criação

#2. **Moto:**
   - Identificador (chave primária)
   - Ano
   - Modelo
   - Placa (chave única)
   - Data de Criação

#3. **Entregador:**
   - Identificador (chave primária)
   - Nome
   - CNPJ (chave única)
   - Data de Nascimento
   - Número da CNH (chave única)
   - Tipo de CNH (A, B ou Ambas)
   - Imagem CNH
   - Data de Criação

#4. **Locação:**
   - Identificador (chave primária)
   - Data de Início
   - Data de Término
   - Data de Previsão de Término
   - Valor Total
   - Entregador (chave estrangeira referenciando Entregador)
   - Moto (chave estrangeira referenciando Moto)
   - Data de Criação

#5. **Plano de Locação:**
   - Tipo de Plano (7 dias, 15 dias, 30 dias)
   - Valor por Dia
   - Multa Em Porcentagem
   - Valor Adiconal por Diaria	
   - Data de Criação

#6. **Pedido:**
   - Identificador (chave primária)
   - Valor da Corrida
   - Situação (Disponível, Aceito, Entregue)
   - Data de Criação

#7. **Notificação:**
   - Identificador (chave primária)
   - Data e Hora da Notificação
   - Entregador (chave estrangeira referenciando Entregador)
   - Pedido (chave estrangeira referenciando Pedido)
   - Data de Criação

#8. **TipoCNH:**
   - Identificador (chave primária)
   - Nome (A, B, Ambas)

#9. **TipoSituacaoPedido:**
   - Identificador (chave primária)
   - Nome (Disponível, Aceito, Entregue)


### Regras de negocio:

### Para o Ator Admin:

1. **Cadastro de Moto:**
   - O admin pode cadastrar uma nova moto com os seguintes dados obrigatórios: ano, modelo e placa.
   - A placa é um dado único e não pode se repetir.

2. **Consulta de Motos:**
   - O admin pode visualizar todas as motos cadastradas na plataforma e filtrá-las pela placa.

3. **Modificação Moto:**
   - O admin pode modificar a placa de uma moto cadastrada incorretamente.
   
4. **Remoção de Moto:**
   - O admin pode remover uma moto cadastrada incorretamente, desde que não tenha registros de locações associados a ela.   

5. **Cadastro de Pedidos:**
   - O admin pode cadastrar um novo pedido na plataforma com informações: Intificador, data de criacao, valor da corrida, situacao (disponível, aceito, entregue).
   - Quando o pedido entrar na plataforma a aplicação deverá notificar os entregadores sobre a existencia desse pedido.
   - - A notificação deverá ser publicada por mensageria.
   - - Somente entregadores com locação ativa e que não estejam com um pedido já aceito deverão ser notificados.
   - Criar um consumidor para notificação de pedido disponível.
   - Assim que a mensagem for recebida, deverá ser armazenada no banco de dados para consulta futura.

6. **Consulta de Notificações:**
   - Ele pode consultar todos os entregadores que foram notificados sobre um   específico.

### Para o Ator Entregador:

1. **Cadastro de Entregador:**
   - Um entregador pode se cadastrar na plataforma fornecendo informações como nome, CNPJ, data de nascimento, número da CNH, tipo de CNH e imagem da CNH.
   - O número da CNH e o CNPJ devem ser únicos.

2. **Atualização de Cadastro:**
   - Um entregador pode enviar uma nova foto da sua CNH para atualizar o cadastro.

3. **Locação de Moto:**
   - Um entregador pode alugar uma moto para um período específico.
   - Ele deve ser habilitado na categoria A para alugar uma moto.
   - A locação deve ter uma data de início, uma data de término e uma data de previsão de término.
   - O sistema calculará o valor total da locação com base no plano escolhido e nas datas de locação.

4. **Consulta de Valor Total da Locação:**
   - Um entregador pode consultar o valor total da locação e informar a data em que pretende devolver a moto.

5. **Aceitação e Entrega de Pedidos:**
   - Um entregador pode aceitar um pedido disponível na plataforma.
   - Ele pode efetuar a entrega do pedido após aceitá-lo.

Essas regras de negócio definem as ações permitidas para os atores admin e entregadores na aplicação de gerenciamento de aluguel de motos e entregas.
