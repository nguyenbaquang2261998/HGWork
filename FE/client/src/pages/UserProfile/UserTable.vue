<template>
    <div class="content">
        <div class="md-layout">
            <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
                <md-card>
                    <md-card-header data-background-color="green">
                        <h4 class="title">Danh sách tài khoản</h4>
                        <p class="category">Thông tin các tài khoản</p>
                    </md-card-header>
                    <md-card-content>
                        <template>
                            <div>
                                <md-table v-model="users.data" :table-header-color="tableHeaderColor" md-sort="name"
                                    md-sort-order="asc">
                                    <md-table-row slot="md-table-row" slot-scope="{ item }">
                                        <md-table-cell md-sort-by="name" md-label="Tên người dùng">{{ item.name
                                        }}</md-table-cell>
                                        <md-table-cell md-label="Tài khoản">{{ item.userName }}</md-table-cell>
                                        <md-table-cell md-label="SĐT">{{ item.phone }}</md-table-cell>
                                        <md-table-cell md-label="Email">{{ item.email }}</md-table-cell>
                                        <md-table-cell md-label="Admin">{{ item.isAdmin }}</md-table-cell>
                                        <md-table-cell md-label="Thao tác">
                                            <!-- <md-button @click="doUpdate(item.id)" class="md-fab md-mini" style="margin-left: 10px;background-color: coral!important;">
                                                <md-icon style="margin-right: 15px;">edit</md-icon>
                                            </md-button> -->

                                            <md-button @click="doDelete(item.id)" class="md-fab md-mini" style="margin-left: 10px;background-color: red!important;">
                                                <md-icon style="margin-right: 15px;">delete</md-icon>
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
            users: [],
            errors: []
        }
    },
    created() {
        axios.get(`http://localhost:8080/user/getall`)
            .then(response => {
                this.users = response.data;
                console.log(this.users);
            })
            .catch(e => {
                console.log("error");
            })
    },
    methods: {
        doUpdate() {

        },
        doDelete(userid) {
            axios.get(`http://localhost:8080/user/delete?id=`+ userid)
            .then(response => {
                console.log(response);
                location.reload();
            })
            .catch(e => {
                location.reload();
            })
        }
    }
    
};
</script>