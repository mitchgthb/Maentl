import React from "react";

const Header: React.FC = () => {
  return (
    <header className="w-full h-16 bg-white border-b border-gray-200 flex items-center px-6 shadow-sm z-10">
      <div className="text-xl font-semibold tracking-tight">Maentl App Header</div>
      {/* You can add user menu, logo, or actions here */}
    </header>
  );
};

export default Header;
