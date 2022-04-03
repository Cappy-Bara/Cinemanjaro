import React from 'react';
import './styles.css'
import ShowListDashboard from '../../components/ShowList/ShowListDashboard';
import NavBar from './NavBar';

function App() {
  return (
    <div>
      <NavBar />
      <ShowListDashboard />
    </div>
  );
}

export default App;
