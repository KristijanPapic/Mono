import logo from './logo.svg';
import './App.css';
import Navbar from './components/navbar.js'
import Footer from './components/footer';
import Manufacturers from './components/manufacturers.js';
import Models from './components/models.js'
import ModelVersions from './components/modelVersions';
import axios from 'axios';
import{useState,useEffect} from 'react'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import { Container, footer } from 'reactstrap'





function App() {

  return (
    <Router>
      <div className="App" id='page-container'>
        <Navbar/>
        <Container className='bg-light border mb-5' id='page-content'>
          <Routes>
            <Route
            path='/'
            element={
              <Manufacturers/>
            }
            />
            <Route
            path='/Manufacturer/:id'
            element={
              <Models/>
            }
            />
            <Route
            path='/Model/:modelId'
            element={
              <ModelVersions/>
            }
            />
            </Routes>
        </Container>
        
      
      </div>
      <Footer/>
    </Router>
    
  );
}

export default App;
