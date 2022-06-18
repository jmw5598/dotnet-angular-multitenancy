export interface BaseMultitenancyEntity {
  id: string,
  createdOn: Date,
  updatedOn: Date,
  deletedOn?: Date
}
