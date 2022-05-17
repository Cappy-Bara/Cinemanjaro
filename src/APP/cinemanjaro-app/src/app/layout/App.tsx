import React, { useState } from 'react';
import './styles.css'
import ShowListDashboard from '../../components/ShowList/ShowListDashboard';
import NavBar from './NavBar';
import BookSeatsDashboard from '../../components/BookSeats/BookSeatsScreen/BookSeatsDashboard';
import { Container } from 'semantic-ui-react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import ThankYouPage from '../../components/BookSeats/ThankYouPage/ThankYouPage';
import AboutUs from '../../components/AboutUs/AboutUs';
import MoviePage from '../../components/MoviePage/MoviePage';
import OnScreenPage from '../../components/OnScreenPage/OnScreenPage';
import HomePage from '../../components/HomePage/HomePage';
import LoginScreen from '../../components/LoginScreen/LoginScreen';
import RegisterScreen from '../../components/RegisterScreen/RegisterScreen';
import ThankYouPageRegister from '../../components/RegisterScreen/ThankYouPageRegister';

function App() {
  const [loggedUser, setLoggedUser] = useState('');

  return (
    <>
      <NavBar loggedUser={loggedUser}/>
      <Container style={{ marginTop: '7em' }}>
        <Routes>
          <Route path={'/'} element={<HomePage />} />
          <Route path={'/aboutus'} element={<AboutUs />} />
          <Route path={'/movies/:id'} element={<MoviePage />} />
          <Route path={'/shows'} element={<ShowListDashboard />} />
          <Route path={'/shows/:id'} element={<BookSeatsDashboard />} />
          <Route path={'/success'} element={<ThankYouPage />} />
          <Route path={'/movies'} element={<OnScreenPage />} />
          <Route path={'/login'} element={<LoginScreen setLoggedUser={setLoggedUser}/>} />
          <Route path={'/register'} element={<RegisterScreen />} />
          <Route path={'/register-succeeded'} element={<ThankYouPageRegister />} />
        </Routes>
      </Container>
    </>
  );
}

export default App;
