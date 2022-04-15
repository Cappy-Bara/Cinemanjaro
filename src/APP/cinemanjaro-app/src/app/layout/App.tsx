import React from 'react';
import './styles.css'
import ShowListDashboard from '../../components/ShowList/ShowListDashboard';
import NavBar from './NavBar';
import BookSeatsDashboard from '../../components/BookSeats/BookSeatsScreen/BookSeatsDashboard';
import { Container } from 'semantic-ui-react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';

function App() {
  return (
    <>
      {/* <Route
        path={`/(.+)`}
        children={() => ( */}
          <>
            <NavBar />
            <Container style={{ marginTop: '7em' }}>
                <Routes>
                  <Route path={'/shows'} element={<ShowListDashboard />} />
                  <Route path={'/shows/:id'} element={<BookSeatsDashboard />} />
                </Routes>
            </Container>
          </>
        {/* )}
      /> */}
    </>
  );
}

export default App;
