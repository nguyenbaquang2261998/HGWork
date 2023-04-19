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
                                <md-table v-model="projects.data" :table-header-color="tableHeaderColor" md-sort="name" md-sort-order="asc">
                                    <md-table-row slot="md-table-row" slot-scope="{ item }">
                                        <md-table-cell md-sort-by="name" md-label="Tên dự án">{{ item.name }}</md-table-cell>
                                        <md-table-cell md-label="Code">{{ item.code }}</md-table-cell>
                                        <md-table-cell md-label="Mô tả">{{ item.description }}</md-table-cell>
                                        <md-table-cell md-sort-by="startDate" md-label="Ngày bắt đầu">{{ item.startDate }}</md-table-cell>
                                        <md-table-cell md-sort-by="startDate" md-label="Ngày kết thúc">{{ item.endDate }}</md-table-cell>
                                        <md-table-cell md-label="Thao tác">
                                            <md-button @click="toList(item.id)" class="md-fab md-mini" style="background-color: green!important;">
                                                <md-icon style="margin-right: 15px;">checklist</md-icon>
                                            </md-button>
                                            <md-button @click="toUpdate(item.id)" class="md-fab md-mini" style="margin-left: 10px;background-color: coral!important;">
                                                <md-icon style="margin-right: 15px;">edit</md-icon>
                                            </md-button>
                                        </md-table-cell>
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
    methods: {
        toList(projectId) {
            location.href = "http://localhost:8080/#/listtasks/" + projectId;
        },
        toUpdate(projectId) {
            location.href = "http://localhost:8080/#/updateproject/" + projectId;
        },
        formatDate(input) {
            var datePart = input.match(/\d+/g),
                year = datePart[0], // get only two digits
                month = datePart[1], day = datePart[2];

            return year + '-' + month + '-' + day;
        }
    }
};
</script>