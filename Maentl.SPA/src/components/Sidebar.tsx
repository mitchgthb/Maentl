import React from "react";
import { NavLink } from "react-router-dom";

const navItems = [
  { path: "/documents", label: "Documents" },
  { path: "/customers", label: "Customers" },
  { path: "/projects", label: "Projects" },
  { path: "/login", label: "Works" },
];

const Sidebar: React.FC = () => {
  return (
    <aside className="w-64 h-screen bg-white border-r border-gray-200 flex flex-col p-4 shadow-sm">
      <div className="text-2xl font-bold mb-8">Maentl</div>
      <nav className="flex flex-col gap-2">
        {navItems.map((item) => (
          <NavLink
            key={item.path}
            to={item.path}
            className={({ isActive }) =>
              `px-4 py-2 rounded transition-colors ${isActive ? "bg-blue-500 text-white" : "text-gray-700 hover:bg-gray-100"}`
            }
          >
            {item.label}
          </NavLink>
        ))}
      </nav>
    </aside>
  );
};

export default Sidebar;
