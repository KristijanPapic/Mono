import axios from 'axios';
import { useState, useEffect } from 'react'
import { Container, Row, Col, Input, Spinner, Label } from 'reactstrap';
import Manufacturer from './manufacturer';
import '../App.css';
import ReactPaginate from 'react-paginate';
import SearchBar from './searchBar';



function Manufacturers() {
    const [manufacturers, setManufacturers] = useState({})
    const [sort, setSort] = useState('ASC')
    const [page,setPage] = useState(1)
    const [search,setSearch] = useState("")

    useEffect(() => {
        const getManufacturers = async () => {
            await fetchManufacturers();
        }
        getManufacturers()
    }, [sort,page,search])


    const fetchManufacturers = async () => {
        axios.get('https://localhost:44343/api/Manufacturer', { params: {name: search, sortMethod: sort, page: page } }).then((response) => {
            console.log(response.data);
            console.log(response.data.Manufacturers)
            setManufacturers(response.data);
            return response.data;
        })
    };

    const sorting = (e) => {
        setSort(e.target.value)
    }

    const changePage = (e) => {
        setPage(e.selected + 1)
    }

    const handleClick = (input) => {
        setSearch(input);
    }
    return (


        <Container>
            <SearchBar click={handleClick}/>
            <Row>
                <Col md="9">
                    <h3 id='header'>Manufacturers</h3>
                </Col>
                <Col md="1">
                    <Label for='sort_select' className='ms-3'>Sort:</Label>
                </Col>
                <Col md="2">
                    <Input type='select' id='sort_select' name='sort_select' size="sm" onChange={sorting}>
                        <option selected value='ASC'>
                            Name - ASC
                        </option>
                        <option value='DESC'>
                            Name - DSC
                        </option>
                    </Input>
                </Col>

            </Row>
            {manufacturers == null || manufacturers.Manufacturers == undefined ? (
                <Spinner
                    color="primary"
                    size=""
                >
                    Loading...
                </Spinner>
            ) : (
                <Row>
                    {manufacturers.Manufacturers.map((manufacturer) => (
                        <Col key={manufacturer.Id}>
                            <Manufacturer manufacturer={manufacturer} />
                        </Col>
                    ))}

                </Row>
            )}
            <Row>
                <Col className='d-flex justify-content-center mt-3'>
                <ReactPaginate
                    nextLabel=">>"
                    marginPagesDisplayed={2}
                    pageCount={manufacturers.TotalItemCount / 18}
                    onPageChange={changePage}
                    previousLabel="<<"
                    pageClassName="page-item"
                    pageLinkClassName="page-link"
                    previousClassName="page-item"
                    previousLinkClassName="page-link"
                    nextClassName="page-item"
                    nextLinkClassName="page-link"
                    breakLabel="..."
                    breakClassName="page-item"
                    breakLinkClassName="page-link"
                    containerClassName="pagination"
                    activeClassName="active"
                    renderOnZeroPageCount={null}
                />
                </Col>
                
            </Row>

        </Container>

    );
}

export default Manufacturers