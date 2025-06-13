import type React from "react"
import { BrowserRouter } from "react-router-dom"
import { AuthProvider } from "./context/AuthContext"
import AppRoutes from "./routes"
import Sidebar from "./components/Sidebar"
import Header from "./components/Header"

const App: React.FC = () => {
  return (
    <AuthProvider>
      <BrowserRouter>
        <div className="flex min-h-screen bg-background">
          <Sidebar />
          <div className="flex-1 flex flex-col min-h-screen">
            <Header />
            <main className="flex-1 p-6">
              <AppRoutes />
            </main>
          </div>
        </div>
      </BrowserRouter>
    </AuthProvider>
  )
}

export default App
