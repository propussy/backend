package server

import (
	"context"
	"fmt"
	"log/slog"
	"net/http"

	"github.com/propussy/backend/internal/config"
)

type Server struct {
	httpServer *http.Server
	logger     *slog.Logger
	config     *config.AppConfig

	// Module properties
}

func New(cfg *config.AppConfig, log *slog.Logger) *Server {
	srv := &Server{
		logger: log,
		config: cfg,
	}

	mux := srv.setupRoutes()
	srv.httpServer = &http.Server{
		Addr:    fmt.Sprintf("%s:%d", cfg.HttpConfig.Addr, cfg.HttpConfig.Port),
		Handler: mux,
	}

	return srv
}

func (s *Server) Start() error {
	s.logger.LogAttrs(
		context.Background(),
		slog.LevelInfo,
		"Starting HTTP server",
		slog.String(
			"Address",
			fmt.Sprintf("%s:%d", s.config.HttpConfig.Addr, s.config.HttpConfig.Port),
		),
	)
	return s.httpServer.ListenAndServe()
}
