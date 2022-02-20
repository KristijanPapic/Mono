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

  const [manufacturers,setManufacturers]= useState([])

  useEffect(() => {
    const getManufacturers = async () => {
      await fetchManufacturers();
    }
    getManufacturers()
  }, [])
  
  
  const fetchManufacturers = async () => {
    axios.get('https://localhost:44343/api/Manufacturer').then((response) => {
      console.log(response.data);
        setManufacturers(response.data);
        return response.data;
      })
    };
  return (
    <Router>
      <div className="App" id='page-container'>
        <Navbar/>
        <Container className='bg-light border vh-100 mb-5' id='page-content'>
          <Routes>
            <Route
            path='/'
            element={
              <Manufacturers manufacturers={manufacturers}/>
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
