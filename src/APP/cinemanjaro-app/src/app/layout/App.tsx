import React from 'react';
import './styles.css'
import ShowListDashboard from '../../components/ShowList/ShowListDashboard';
import NavBar from './NavBar';
import BookSeatsDashboard from '../../components/BookSeatsScreen/BookSeatsDashboard';
import { Container } from 'semantic-ui-react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';

function App() {
  return (
    <div>
      <NavBar />
      <Container style={{ marginTop: '7em' }}>
      <BrowserRouter>
        <Routes>
          <Route path={'/shows'} element={<ShowListDashboard />} />
          <Route path={'/shows/:id'} element={<BookSeatsDashboard />} />
        </Routes>
      </BrowserRouter>
      </Container>
    </div>
  );
}

export default App;
