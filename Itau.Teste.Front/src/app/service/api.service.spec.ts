import { TestBed } from '@angular/core/testing';

import { ApiLancamentoService } from './api-lancamento.service';

describe('ApiService', () => {
  let service: ApiLancamentoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiLancamentoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
