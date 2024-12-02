#!/bin/bash

repo="slobodanstar/dishdive_frontend"
tag="latest"

docker build -t $repo:$tag .

docker login

docker push $repo:$tag