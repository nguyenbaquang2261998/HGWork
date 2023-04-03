<template>
    <div class="content">
        <div class="md-layout">
            <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
                <md-card>
                    <md-card-header data-background-color="green">
                        <h4 class="title">Các dự án đã triển khai</h4>
                        <p class="category">Thông tin các dự án đã triển khai</p>
                    </md-card-header>
                    <md-card-content>
                        <template>
                            <div>
                                <md-table v-model="projects.data" :table-header-color="tableHeaderColor">
                                    <md-table-row slot="md-table-row" slot-scope="{ item }">
                                        <md-table-cell md-label="Tên dự án">{{ item.name }}</md-table-cell>
                                        <md-table-cell md-label="Code">{{ item.code }}</md-table-cell>
                                        <md-table-cell md-label="Mô tả">{{ item.description }}</md-table-cell>
                                        <md-table-cell md-label="Ngày bắt đầu">{{ item.startDate }}</md-table-cell>
                                        <md-table-cell md-label="Ngày kết thúc">{{ item.endDate }}</md-table-cell>
                                    </md-table-row>
                                </md-table>
                            </div>
                        </template>
                    </md-card-content>
                </md-card>
            </div>
        </div>
    </div>
</template>
<script>
import axios from 'axios';
export default {
    props: {
        tableHeaderColor: {
            type: String,
            default: "",
        },
    },
    data() {
        return {
            projects: [],
            errors: []
        }
    },
    created() {
        axios.get(`http://localhost:8080/project/getall`)
            .then(response => {
                this.projects = response.data;
                console.log(this.projects);
            })
            .catch(e => {
                console.log("error");
            })
    },
};
</script>