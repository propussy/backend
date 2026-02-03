package users

import (
	"log/slog"
)

type UsersModule struct {
	logger *slog.Logger
}

func New(logger *slog.Logger) *UsersModule {
	return &UsersModule{
		logger: logger.With("module", "users"),
	}
}
