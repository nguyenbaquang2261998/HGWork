<template>
    <div class="content">
        <div class="md-layout">
            <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
                <md-card>
                    <md-card-header data-background-color="green">
                        <h4 class="title">Các công việc</h4>
                        <p class="category">Thông tin các công việc</p>
                        <div style="width:25%">
                            <md-field class="disable-line">
                                <label style="margin: 0px 0px 10px 5px; color: black !important;"><md-icon>search</md-icon>Tìm kiếm: Nhập tên công việc hoặc mã công việc...</label>
                                <md-input v-on:blur="filter();" id="keyword" style="background-color: lightcyan !important; border-radius: 5px;" v-model="keyword"></md-input>
                            </md-field>
                        </div>
                    </md-card-header>
                    <md-card-content>
                        <template>
                            <div>
                                <md-table v-model="tasks.data" :table-header-color="tableHeaderColor" md-sort="name"
                                    md-sort-order="asc">
                                    <md-table-row slot="md-table-row" slot-scope="{ item }">
                                        <md-table-cell md-sort-by="name" md-label="Tên task">{{ item.name }}</md-table-cell>
                                        <md-table-cell md-label="Code">{{ item.code }}</md-table-cell>
                                        <md-table-cell md-label="Mô tả">{{ item.description }}</md-table-cell>
                                        <md-table-cell md-sort-by="startDate" md-label="Ngày bắt đầu">{{ item.startDate}}</md-table-cell>
                                        <md-table-cell md-sort-by="startDate" md-label="Ngày kết thúc">{{ item.endDate}}</md-table-cell>
                                        <md-table-cell md-label="Thao tác">
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
            tasks: [],
            errors: [],
            keyword: ''
        }
    },
    created() {
        const param = this.$route.params.id;
        axios.get(`http://localhost:8080/project/gettasks/` + param)
            .then(response => {
                this.tasks = response.data;
                console.log(this.tasks);
            })
            .catch(e => {
                console.log("error");
            })
    },
    methods:{
        toUpdate(taskId) {
            location.href = "http://localhost:8080/#/updatetask/" + taskId;
        },
        filter(){
            if(this.keyword == ''){
                axios.get(`http://localhost:8080/task/getall`)
            .then(response => {
                this.tasks = response.data;
            })
            .catch(e => {
                console.log("error");
            })
            }
            else
            {axios.get(`http://localhost:8080/task/filter/`+ this.keyword)
                .then(response => {
                    this.tasks = response.data;
                })
                .catch(e => {
                    console.log("error");
            })}
        }
    }
};
</script>
<style>
.disable-line:after {
    height: 0px!important;
}
</style>