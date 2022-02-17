import {useParams} from 'react-router-dom'
import{useState} from 'react'
import axios from 'axios';
import{Container,Row} from 'reactstrap'
import Model from './model.js'

function Models(){
    const[manufacturerDetail,setManufacturerDetail] = useState([]);
    const {id} = useParams();

    const FetchManufacturerById = async() => {
        axios.get('https://localhost:44343/api/Manufacturer/' + id).then((response) => {
            console.log(response.data);
            setManufacturerDetail(response.data);
        })
    }
    FetchManufacturerById();

    return (
    <Container>
        <h1>{manufacturerDetail.Name}</h1>
        <h3>Models:</h3>
        {console.log(manufacturerDetail.Models)}
        {manufacturerDetail.Models.map((model) => (
            <Model model={model}/>
    ))}
    </Container>
     

    );
}
export default Models;