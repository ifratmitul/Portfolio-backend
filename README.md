# Portfolio

Run to commands in the following order to run the project. (Before running the command make sure you have `docker`, `node.js`, `next.js` and `.NET6` installed in your device)

## Docker command to create db image

`docker run --name Portfolio -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=secret -p 5432:5432 -d postgres:latest`

## Run Back-end

Change directory to API run `dotnet build` then run `dotnet watch run`

## Run front-end

Change directory to client/ then run `npm run dev` in your terminal.
