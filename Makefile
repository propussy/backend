.PHONY: run build

run:
	go run cmd/api/main.go

run-local:
	CONFIG_PATH=config/local.yaml make run

build:
	go build -o bin/api cmd/api/main.go
