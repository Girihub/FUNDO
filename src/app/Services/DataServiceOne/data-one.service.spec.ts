import { TestBed } from '@angular/core/testing';

import { DataOneService } from './data-one.service';

describe('DataOneService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DataOneService = TestBed.get(DataOneService);
    expect(service).toBeTruthy();
  });
});
