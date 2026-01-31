package logger

import (
	"log/slog"
	"os"
)

func InitializeLogger() *slog.Logger {
	l := slog.New(slog.NewJSONHandler(os.Stdout, nil))

	slog.SetDefault(l)

	return l
}
