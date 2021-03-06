import {useParams} from 'react-router-dom'
import{useState,useEffect} from 'react'
import axios from 'axios';
import{Container,Spinner,Col,Row,Input,Label} from 'reactstrap'
import Model from './model.js'
import '../App.css'
import SearchBar from './searchBar.js';

function Models(){
    const [manufacturerDetail,setManufacturerDetail] = useState([]);
    const [sort,setSort] = useState('ASC');
    const [search,setSearch] = useState("");
    const {id} = useParams();

    useEffect(() => {
        const Get = async () => {
            await FetchManufacturerById();
            }
        Get()
    },[sort,search])

    const FetchManufacturerById = async () => {
        axios.get('https://localhost:44343/api/Manufacturer/' + id,{params: {modelFilter: search ,modelSortMethod: sort}}).then((response) => {
            console.log(response)
            setManufacturerDetail(response.data)
        })
    }

    const sorting = (e) => {
        console.log(e.target.value)
        setSort(e.target.value) 
    }
    const handleClick = (input) => {
        setSearch(input)
    }
    return (
    <Container>
        <SearchBar click={handleClick}/>
        <Row>
            <Col md='9'>
                <h1 id='header'>{manufacturerDetail.Name}</h1>
            </Col>
            <Col md='1'>
                <Label for='sort_select'>Sort</Label>
            </Col>
            <Col md='2'>
            <Input type='select' id='sort_select' name='sort_select' size="sm" onChange={sorting}>
                    <option selected value='ASC'>
                        Name - ASC
                    </option>
                    <option value='DESC'>
                        Name - DESC
                    </option>
                </Input>
            </Col>
        </Row>
        
        <h3>Models:</h3>
        {manufacturerDetail.Models == undefined ? (
            <Spinner
            color="primary"
            size=""
          >
            Loading...
          </Spinner>
        ) : 
        (manufacturerDetail.Models.map((model) => (
            <Model model = {model}/>
        )))
        }
    </Container>
     

    );
}
export default Models;