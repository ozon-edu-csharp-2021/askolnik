#!/bin/bash

set -e
run_cmd="dotnet MerchApi.dll --no-build -v d"

dotnet MerchApi.Migrator.dll --no-build -v d -- --dryrun

dotnet MerchApi.Migrator.dll --no-build -v d

>&2 echo "MerchApi DB Migrations complete, starting app."
>&2 echo "Run StockApi: $run_cmd"
exec $run_cmd