import React from 'react';
import './styles.css'
import ShowListDashboard from '../../components/ShowList/ShowListDashboard';
import NavBar from './NavBar';
import BookSeatsDashboard from '../../components/BookSeats/BookSeatsScreen/BookSeatsDashboard';
import { Container } from 'semantic-ui-react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import ThankYouPage from '../../components/BookSeats/ThankYouPage/ThankYouPage';
import AboutUs from '../../components/BookSeats/AboutUs/AboutUs';

function App() {
  return (
    <>
      <NavBar />
      <Container style={{ marginTop: '7em' }}>
        <Routes>
          <Route path={'/aboutus'} element={<AboutUs />} />
          <Route path={'/shows'} element={<ShowListDashboard />} />
          <Route path={'/shows/:id'} element={<BookSeatsDashboard />} />
          <Route path={'/success'} element={<ThankYouPage />} />
        </Routes>
      </Container>
    </>
  );
}

export default App;
