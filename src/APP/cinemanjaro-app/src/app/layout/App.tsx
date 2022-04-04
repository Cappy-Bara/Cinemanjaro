import React from 'react';
import './styles.css'
import ShowListDashboard from '../../components/ShowList/ShowListDashboard';
import NavBar from './NavBar';
import BookSeatsDashboard from '../../components/BookSeatsScreen/BookSeatsDashboard';

function App() {
  return (
    <div>
      <NavBar />
      {/* <ShowListDashboard /> */}
      <BookSeatsDashboard />
    </div>
  );
}

export default App;
