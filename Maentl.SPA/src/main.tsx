import React from "react"
import ReactDOM from "react-dom/client"
import { MsalProvider } from "@azure/msal-react"
import { pca } from "./services/msalConfig"
import App from "./App"
import "./index.css"

const root = ReactDOM.createRoot(document.getElementById("root") as HTMLElement)

root.render(
  <React.StrictMode>
    {/*<MsalProvider instance={pca}>*/}
      <App />
      <div>Hello</div>
    {/*</MsalProvider>*/}
  </React.StrictMode>,
)
