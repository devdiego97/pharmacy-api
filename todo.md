[]Divisão de camadas
[]Swaggwer
[]Seed
[]Fazer as 5 operações de crud(get,get id,post,put,pacth,delete)
[]Retornar relacionamentos nos cruds
  - Os Dtos devem ter os relacionamentos
  - Os dtos de include não devem ter tudo
[]Tratamento de erros globais
[]Aplicar paginacao,filtros
[]Camadas da Clean Arquitecture




[]Tools
  []Polly
  []Swagger
  []Dockerfile e docker compose
  []Redis
  []Upload 
  []CQRS








# 1. Clonar o repositório
git clone repo

# 2. Entrar na pasta
cd nome-do-projeto

# 3. Criar e trocar para a branch
git switch -c nome-da-branch

# 4. Trabalhar normalmente
git add .
git commit -m "mensagem"

# 5. Enviar a branch para o remoto (IMPORTANTE)
git push origin nome-da-branch

# 6. Voltar para a main
git switch main

# 7. Atualizar a main
git pull origin main

# 8. Fazer o merge
git merge nome-da-branch

# 9. Subir a main atualizada
git push origin main

# 10. Deletar a branch
git branch -d nome-da-branch
git push origin --delete nome-da-branch