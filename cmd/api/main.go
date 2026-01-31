package main

import (
	"log/slog"

	"github.com/propussy/backend/internal/config"
	"github.com/propussy/backend/internal/server"
	"github.com/propussy/backend/pkg/logger"
)

func main() {
	log := logger.InitializeLogger()

	cfg := config.MustLoad()

	srv := server.New(cfg, log)

	slog.Info("Starting")

	if err := srv.Start(); err != nil {
		panic(err)
	}
	panic("Vro")
}
