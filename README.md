# Immo Listing

[![(API) Build and test](https://github.com/alopes2/immo-listing/actions/workflows/build.yml/badge.svg)](https://github.com/alopes2/immo-listing/actions/workflows/build.yml)

Application for listing properties

## API

See [API](src/api/README.md)

## Client

See [Client](src/client/README.md)

## Testing

To quickly bootstrap and test you'll need docker installed.
Then run

`docker compose up`

This command will spin up the API, the client and a SQL Server 2019 instance for testing.

To access the services:

API - `http://localhost:5000`
Client - `http://localhost:5173`