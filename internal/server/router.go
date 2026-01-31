package server

import (
	"net/http"
)

func (srv *Server) setupRoutes() *http.ServeMux {
	mux := http.NewServeMux()

	mux.HandleFunc("/", func(w http.ResponseWriter, r *http.Request) {
		w.Write([]byte("{ \"hello\": \"world\" }"))
	})

	return mux
}
